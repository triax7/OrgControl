import Box from '@material-ui/core/Box';
import { IconButton, Typography } from '@material-ui/core';
import { Add, Close, Done } from '@material-ui/icons';
import React, { useEffect, useState } from 'react';
import { assignRoleToUser, getFromUserInEvent } from '../../api/Roles';
import Paper from '@material-ui/core/Paper';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { useSelector } from 'react-redux';
import TextField from '@material-ui/core/TextField';

export default function UserRoleManager({userId, eventId}) {

  const [userRoles, setUserRoles] = useState([]);
  const [addingRole, setAddingRole] = useState(false);
  const [selectedRole, setSelectedRole] = useState(null);

  const roles = useSelector(state => state.roles);

  useEffect(() => {
    async function getUserRoles() {
      const {data} = await getFromUserInEvent(userId, eventId);
      setUserRoles(data);
    }

    getUserRoles();
  }, [userId, eventId]);

  function handleRemoveRole(roleId) { // TODO: Add removing roles from user

  }

  async function handleAssignRole() {
    try {
      await assignRoleToUser(userId, selectedRole.id);
      setUserRoles(roles => [...roles, selectedRole]);
      setAddingRole(false);
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
                options={roles}
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
