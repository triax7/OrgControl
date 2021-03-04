import AppBar from '@material-ui/core/AppBar';
import Box from '@material-ui/core/Box';
import ButtonGroup from '@material-ui/core/ButtonGroup';
import Button from '@material-ui/core/Button';
import React, {useEffect} from 'react';
import {useDispatch, useSelector} from 'react-redux';
import {push} from 'connected-react-router';
import {getCurrentUser, logoutUser} from '../redux/slices/userSlice';

export default function Header() {
  const dispatch = useDispatch();

  const isLoggedIn = useSelector(state => !!state.user.id);

  useEffect(() => {
    dispatch(getCurrentUser())
  });

  function handleLogout() {
    dispatch(logoutUser())
  }

  return (
    <AppBar position={'sticky'} style={{backgroundColor: '#9dc89a'}}>
      <Box display={'flex'} justifyContent={'center'} alignItems={'center'}>
        {isLoggedIn ?
          <Box p={1}>
            <ButtonGroup>
              <Button onClick={() => dispatch(push('/events'))}>Events</Button>
              <Button onClick={() => dispatch(push('/assignments'))}>Assignments</Button>
              <Button onClick={handleLogout}>Logout</Button>
            </ButtonGroup>
          </Box> :
          <Box p={1}>
            <ButtonGroup>
              <Button onClick={() => dispatch(push('/register'))}>Register</Button>
              <Button onClick={() => dispatch(push('/login'))}>Login</Button>
            </ButtonGroup>
          </Box>}
      </Box>
    </AppBar>
  );
}
