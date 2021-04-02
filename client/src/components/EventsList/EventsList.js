import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect } from 'react';
import { createEvent, getEvents } from '../../redux/slices/eventsSlice';
import { Grid } from '@material-ui/core';
import EventCard from './EventCard';
import Box from '@material-ui/core/Box';
import SingleFieldAddForm from '../util/SingleFieldAddForm';

export default function EventList() {
  const dispatch = useDispatch();


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
        <SingleFieldAddForm onSubmit={(name) => dispatch(createEvent({name}))}
                            placeholder={'Event Name'}/>
      </Grid>
    </Grid>
  );
}


