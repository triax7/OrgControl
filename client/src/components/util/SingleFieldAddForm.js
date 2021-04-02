import Box from '@material-ui/core/Box';
import { IconButton } from '@material-ui/core';
import { Add, Done } from '@material-ui/icons';
import Paper from '@material-ui/core/Paper';
import React, { useState } from 'react';
import TextField from '@material-ui/core/TextField';

export default function SingleFieldAddForm({onSubmit, placeholder}) {

  const [open, setOpen] = useState(false)
  const [value, setValue] = useState('');

  function handleSubmit() {
    onSubmit(value);
    setOpen(false);
  }

  return (<>
    {!open ?
    <Box display={'flex'} justifyContent={'center'}>
      <IconButton onClick={() => setOpen(true)} size={'small'}>
        <Add fontSize={'large'}/>
      </IconButton>
    </Box> :
    <Paper variant={'outlined'}>
      <Box p={1} display={'flex'} alignItems={'center'}>
        <TextField
          value={value}
          onChange={(event) => setValue(event.target.value)}
          placeholder={placeholder}
          fullWidth/>
        <IconButton onClick={handleSubmit}>
          <Done/>
        </IconButton>
      </Box>
    </Paper>
    }
  </>);
}
