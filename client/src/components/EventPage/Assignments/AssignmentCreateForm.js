import Paper from '@material-ui/core/Paper';
import React, { useEffect, useState } from 'react';
import TextField from '@material-ui/core/TextField';
import Box from '@material-ui/core/Box';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { useDispatch, useSelector } from 'react-redux';
import Checkbox from '@material-ui/core/Checkbox';

import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';
import CheckBoxIcon from '@material-ui/icons/CheckBox';
import { getRoles } from '../../../redux/slices/rolesSlice';
import Button from '@material-ui/core/Button';
import { colors } from '../../../theme/colors';
import { createAssignment } from '../../../redux/slices/assignmentsSlice';

const icon = <CheckBoxOutlineBlankIcon fontSize="small"/>;
const checkedIcon = <CheckBoxIcon fontSize="small"/>;

export default function AssignmentCreateForm({eventId, onSubmit}) {
  const dispatch = useDispatch();

  const [inputName, setInputName] = useState('');
  const [inputDescription, setInputDescription] = useState('');
  const [allowedRoles, setAllowedRoles] = useState([]);

  const roles = useSelector(state => state.roles);

  useEffect(() => {
    async function getEventRoles() {
      if (roles.length === 0) dispatch(getRoles(eventId));
    }

    getEventRoles();
  }, [eventId, roles, dispatch]);

  function handleSubmit() {
    dispatch(createAssignment({
      eventId: eventId,
      name: inputName,
      description: inputDescription,
      allowedRoleIds: allowedRoles.map(role => role.id)
    }));
    onSubmit();
  }

  return (
    <Paper variant={'outlined'}>
      <Box p={2}>
        <Box mb={2}>
          <TextField
            placeholder={'Name'}
            value={inputName}
            onChange={(event) => setInputName(event.target.value)}
            fullWidth
          />
        </Box>
        <Box mb={2}>
          <TextField
            placeholder={'Description'}
            value={inputDescription}
            onChange={(event) => setInputDescription(event.target.value)}
            fullWidth
          />
        </Box>
        <Box mb={2}>
          <Autocomplete
            multiple
            options={roles}
            disableCloseOnSelect
            getOptionLabel={(option) => option.name}
            value={allowedRoles}
            onChange={(event, newValue) => {
              setAllowedRoles(newValue);
            }}
            renderOption={(option, {selected}) => (
              <React.Fragment>
                <Checkbox
                  icon={icon}
                  checkedIcon={checkedIcon}
                  style={{marginRight: 8}}
                  checked={selected}
                />
                {option.name}
              </React.Fragment>
            )}
            renderInput={(params) => (
              <TextField {...params} variant="outlined" placeholder="Allowed Roles"/>
            )}
          />
        </Box>
        <Box display={'flex'} justifyContent={'center'}>
          <Button style={{backgroundColor: colors.header.main}}
                  variant={'contained'}
                  onClick={handleSubmit}>
            Create Assignment
          </Button>
        </Box>
      </Box>
    </Paper>
  );
}
