import React, { useEffect } from 'react';
import { Grid, Typography } from '@material-ui/core';
import RoleManager from './RoleManager';
import { useParams } from 'react-router';
import Box from '@material-ui/core/Box';
import { useDispatch, useSelector } from 'react-redux';
import UserManager from './UserManager';
import { getEvents } from '../../redux/slices/eventsSlice';

export default function EventPage() {
  const {id} = useParams();
  const event = useSelector(state => state.events.find(e => e.id === id));

  const dispatch = useDispatch();
  useEffect(() => {
    if (!event) dispatch(getEvents());
  }, [dispatch, event]);

  return (
    <>
      {!event ? <Typography>Loading...</Typography> :
        <Grid container justify={'center'}>
          <Grid item xs={5}>
            <Box display={'flex'} justifyContent={'center'} mb={3}>
              <Typography variant={'h4'}>{event.name}</Typography>
            </Box>
            <RoleManager eventId={id}/>
            <Box mt={3}>
              <UserManager eventId={event.id}/>
            </Box>
          </Grid>
        </Grid>
      }
    </>
  );
}


