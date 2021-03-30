import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect, useState } from 'react';
import { getEvents } from '../../redux/slices/eventsSlice';
import { Grid, IconButton } from '@material-ui/core';
import EventCard from './EventCard';
import { Add } from '@material-ui/icons';
import Box from '@material-ui/core/Box';
import EventCreateForm from './EventCreateForm';

export default function EventList() {
  const dispatch = useDispatch();

  const [creatingEvent, setCreatingEvent] = useState(false);

  const events = useSelector(state => [...state.events].sort((a, b) => a.name > b.name ? 1 : -1));

  useEffect(() => {
    dispatch(getEvents());
  }, [dispatch]);

  return (
    <Grid container justify={'center'}>
      <Grid item xs={3}>
        {events.map(e =>
          <Box mb={2} key={e.id}>
            <EventCard event={e}/>
          </Box>
        )}
        {!creatingEvent
          ?
          <Box display={'flex'} justifyContent={'center'}>
            <IconButton onClick={() => setCreatingEvent(true)}>
              <Add fontSize={'large'}/>
            </IconButton>
          </Box>
          :
          <Box mt={1}>
            <EventCreateForm setCreatingEvent={setCreatingEvent}/>
          </Box>
        }
      </Grid>
    </Grid>
  );
}


