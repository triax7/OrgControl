import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect, useState } from 'react';
import { getAssignments } from '../../../redux/slices/assignmentsSlice';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import AssignmentCard from './AssignmentCard';
import TextField from '@material-ui/core/TextField';

export default function AssignmentManager({eventId}) {
  const dispatch = useDispatch();
  const [searchString, setSearchString] = useState('');

  const assignments = useSelector(state => [...state.assignments
    .filter(a => a.name.toLowerCase().includes(searchString.toLowerCase()))]
    .sort((a, b) => a.name > b.name ? 1 : -1));

  useEffect(() => {
    dispatch(getAssignments(eventId));
  }, [dispatch, eventId]);


  return (<>
    <Box m={2}>
      <TextField
        fullWidth
        variant={'outlined'}
        placeholder={'Search Assignments'}
        value={searchString}
        onChange={(event) => setSearchString(event.target.value)}
      />
    </Box>
    <Paper variant={'outlined'}>
      <Box p={3} style={{minHeight: 300, maxHeight: 300, overflowY: 'scroll'}}>
        {assignments.map(assignment =>
          <Box key={assignment.id} mb={3}>
            <AssignmentCard assignment={assignment}/>
          </Box>
        )}
      </Box>
    </Paper>
  </>);
}
