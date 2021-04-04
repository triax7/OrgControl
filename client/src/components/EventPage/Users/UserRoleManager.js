import Box from '@material-ui/core/Box';
import { IconButton, Typography } from '@material-ui/core';
import { Add, Close, Done } from '@material-ui/icons';
import React, { useEffect, useState } from 'react';
import { assignRoleToUser, getFromUserInEvent, removeRoleFromUser } from '../../../api/Roles';
import Paper from '@material-ui/core/Paper';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { useDispatch, useSelector } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import { getRoles } from '../../../redux/slices/rolesSlice';

export default function UserRoleManager({userId, eventId}) {

  const dispatch = useDispatch();
  const [userRoles, setUserRoles] = useState([]);
  const [addingRole, setAddingRole] = useState(false);
  const [selectedRole, setSelectedRole] = useState(null);

  const roles = useSelector(state => state.roles);

  useEffect(() => {
    async function getUserRoles() {
      const {data} = await getFromUserInEvent(userId, eventId);
      if (roles.length === 0) dispatch(getRoles(eventId));
      setUserRoles(data);
    }

    getUserRoles();
  }, [userId, eventId, roles, dispatch]);

  async function handleRemoveRole(roleId) {
    try {
      await removeRoleFromUser(userId, roleId);
      setUserRoles(userRoles.filter(role => role.id !== roleId));
    } catch (e) {
      console.log(e);
    }
  }

  async function handleAssignRole() {
    if(!selectedRole) return;
    try {
      await assignRoleToUser(userId, selectedRole.id);
      setUserRoles(roles => [...roles, selectedRole]);
      setAddingRole(false);
      setSelectedRole(null);
    } catch (e) {
      console.log(e);
    }
  }

  return (
    <Paper variant={'outlined'}>
      <Box p={2}>
        <Box display={'flex'} justifyContent={'center'} mb={1}>
          <Typography variant={'h6'}>User Roles</Typography>
        </Box>
        <Box>
          {userRoles.map(role =>
            <Box key={role.id} display={'inline-block'} mr={1} mt={1} pl={2} pr={1}
                 border={1}
                 borderRadius={20}>
              <Box display={'flex'} alignItems={'center'}>
                <Box mr={1}><Typography component={'p'}>{role.name}</Typography></Box>
                <IconButton size={'small'}
                            onClick={() => handleRemoveRole(role.id)}>
                  <Close/>
                </IconButton>
              </Box>
            </Box>
          )}
        </Box>
        <Box mt={2}>
          {!addingRole ?
            <Box display={'flex'} justifyContent={'center'}>
              <IconButton onClick={() => setAddingRole(true)} size={'small'}>
                <Add fontSize={'large'}/>
              </IconButton>
            </Box> :
            <Box p={1} display={'flex'} alignItems={'center'}>
              <Autocomplete
                fullWidth
                onChange={(event, newValue) => {
                  setSelectedRole(newValue);
                }}
                options={roles.filter(role => !userRoles.some(uRole => uRole.id === role.id))}
                getOptionLabel={role => role.name}
                getOptionSelected={role => role.name}
                renderInput={(params) => (
                  <TextField
                    {...params}
                    label={'Select Role'}
                    variant={'outlined'}
                  />
                )}
              />
              <IconButton onClick={handleAssignRole}>
                <Done/>
              </IconButton>
            </Box>
          }
        </Box>
      </Box>
    </Paper>
  );
}
