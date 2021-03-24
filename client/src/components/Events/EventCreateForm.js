import Box from '@material-ui/core/Box';
import { IconButton } from '@material-ui/core';
import { Done } from '@material-ui/icons';
import Paper from '@material-ui/core/Paper';
import React, { useState } from 'react';
import TextField from '@material-ui/core/TextField';
import { useDispatch } from 'react-redux';
import { createEvent } from '../../redux/slices/eventsSlice';

export default function EventCreateForm({setCreatingEvent}) {
  const dispatch = useDispatch();

  const [typedName, setTypedName] = useState('');

  function handleSubmit() {
    dispatch(createEvent({name: typedName}));
    setCreatingEvent(false)
  }

  return (
    <Paper variant={'outlined'}>
      <Box p={1} display={'flex'} alignItems={'center'}>
        <TextField
          value={typedName}
          onChange={(event) => setTypedName(event.target.value)}
          placeholder={'Name'}
          fullWidth/>
        <IconButton onClick={handleSubmit}>
          <Done/>
        </IconButton>
      </Box>
    </Paper>
  );
}
