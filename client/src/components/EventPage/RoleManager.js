import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect } from 'react';
import { IconButton, Typography } from '@material-ui/core';
import { Close } from '@material-ui/icons';
import Box from '@material-ui/core/Box';
import { createRole, deleteRole, getRoles } from '../../redux/slices/rolesSlice';
import Paper from '@material-ui/core/Paper';
import SingleFieldAddForm from '../util/SingleFieldAddForm';

export default function RoleManager({eventId}) {
  const dispatch = useDispatch();

  const roles = useSelector(state => [...state.roles].sort((a, b) => a.name > b.name ? 1 : -1));

  useEffect(() => {
    dispatch(getRoles(eventId));
  }, [dispatch, eventId]);

  function handleDelete(roleId) {
    dispatch(deleteRole(roleId));
  }

  return (
    <Paper variant={'outlined'}>
      <Box p={1} pt={2}>
        <Box display={'flex'} justifyContent={'center'}>
          <Typography variant={'h5'}>Roles in event</Typography>
        </Box>
        <Box p={1} pl={3} pr={3}>
          {roles.map(r =>
            <Box key={r.id} display={'inline-block'} mr={1} mt={1} p={0.5} pl={2} pr={1} border={1}
                 borderRadius={20}>
              <Box display={'flex'} alignItems={'center'}>
                <Box mr={1}><Typography component={'p'}>{r.name}</Typography></Box>
                <IconButton size={'small'} onClick={() => handleDelete(r.id)}>
                  <Close/>
                </IconButton>
              </Box>
            </Box>
          )}
        </Box>
        <Box p={1}>
          <SingleFieldAddForm onSubmit={(name) => dispatch(createRole({eventId, name}))}
                              placeholder={'Role Name'}/>
        </Box>
      </Box>
    </Paper>
  );
}


