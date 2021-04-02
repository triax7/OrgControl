import { Typography } from '@material-ui/core';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import React, { useState } from 'react';
import UserSearch from './UserSearch';
import UserRoleManager from './UserRoleManager';

export default function UserManager({eventId}) {

  const [selectedUser, setSelectedUser] = useState(null);

  return (
    <Paper variant={'outlined'}>
      <Box p={1} pt={2}>
        <Box display={'flex'} justifyContent={'center'}>
          <Typography variant={'h5'}>User Management</Typography>
        </Box>
        <Box display={'flex'} justifyContent={'center'} p={2}>
          <UserSearch onUserSelected={setSelectedUser}/>
        </Box>
        {selectedUser && <>
          <Box m={2}>
            <UserRoleManager userId={selectedUser.id} eventId={eventId}/>
          </Box>
        </>}
      </Box>
    </Paper>
  );
}




