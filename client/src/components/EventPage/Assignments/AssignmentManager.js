import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect, useState } from 'react';
import { getAssignments, updateOrAddAssignment } from '../../../redux/slices/assignmentsSlice';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import AssignmentCard from './AssignmentCard';
import TextField from '@material-ui/core/TextField';
import { Button, Typography } from '@material-ui/core';
import { colors } from '../../../theme/colors';
import { autoAssignDuties } from '../../../api/Assignments';
import AssignmentCreateForm from './AssignmentCreateForm';

export default function AssignmentManager({eventId}) {
  const dispatch = useDispatch();
  const [searchString, setSearchString] = useState('');
  const [selectedAssignments, setSelectedAssignments] = useState([]);
  const [creatingAssignment, setCreatingAssignment] = useState(false);

  const assignments = useSelector(state => [...state.assignments]
    .sort((a, b) => a.name > b.name ? 1 : -1));

  useEffect(() => {
    dispatch(getAssignments(eventId));
  }, [dispatch, eventId]);

  function handleAssignmentClick(assignment) {
    if (assignment.status !== 0) return;
    if (selectedAssignments.find(a => a.id === assignment.id)) {
      setSelectedAssignments(selectedAssignments.filter(a => a.id !== assignment.id));
    } else {
      setSelectedAssignments([...selectedAssignments, assignment]);
    }
  }

  async function handleAssignDuties() {
    const {data} = await autoAssignDuties(selectedAssignments.map(assignment => assignment.id));
    setSelectedAssignments([]);
    data.forEach(assignment => dispatch(updateOrAddAssignment(assignment)));
  }

  return (<>
    <Box m={2} display={'flex'} justifyContent={'center'}>
      <TextField
        fullWidth
        variant={'outlined'}
        placeholder={'Search Assignments'}
        value={searchString}
        onChange={(event) => setSearchString(event.target.value)}
      />
      <Button style={{backgroundColor: colors.header.main}}
              onClick={() => setCreatingAssignment(true)}
              size={'large'} variant={'contained'} disableElevation>
        <Typography variant={'h4'}>+</Typography>
      </Button>
    </Box>
    {!creatingAssignment ?
      <>
        <Box display={'flex'} justifyContent={'center'} my={2}>
          <Button disabled={selectedAssignments.length === 0}
                  style={{backgroundColor: colors.header.main}}
                  variant={'contained'}
                  onClick={handleAssignDuties}>
            Automatically assign duties
          </Button>
        </Box>
        <Paper variant={'outlined'} style={{backgroundColor: '#fcfcfc'}}>
          <Box p={3} pt={4} style={{minHeight: 500, maxHeight: 500, overflowY: 'scroll'}}>
            {assignments.filter(a => a.name.toLowerCase().includes(searchString.toLowerCase())).map(assignment =>
              <Box key={assignment.id} mb={3}>
                <AssignmentCard assignment={assignment}
                                selected={!!selectedAssignments.find(a => a.id === assignment.id)}
                                onClick={() => handleAssignmentClick(assignment)}/>
              </Box>
            )}
          </Box>
        </Paper>
      </>
      :
      <AssignmentCreateForm eventId={eventId} onSubmit={() => setCreatingAssignment(false)}/>
    }
  </>);
}
