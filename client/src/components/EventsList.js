import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect } from 'react';
import { getEvents } from '../redux/slices/eventsSlice';
import Card from '@material-ui/core/Card';
import { CardActionArea, Grid } from '@material-ui/core';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import ColorTypography from './util/ColorTypography';
import { colors } from '../theme/colors';
import Divider from '@material-ui/core/Divider';

export default function EventList() {
  const dispatch = useDispatch();

  const events = useSelector(state => state.events);

  useEffect(() => {
    dispatch(getEvents());
  }, [dispatch]);

  return (
    <Grid container justify={'center'}>
      <Grid item xs={3}>
        {events.map(e => <EventCard event={e} key={e.id}/>)}
      </Grid>
    </Grid>
  );
}

function EventCard({event}) {
  function handleClick() {
    console.log(event);
  }

  return (
    <Card>
      <CardActionArea onClick={handleClick}>
        <Box p={2}>
          <Typography variant="h5" component="h2">
            {event.name}
          </Typography>
        </Box>
        <Divider/>
        <Box p={2}>
          <ColorTypography color={colors.text.notStarted}>
            Not started: {event.assignmentsNotStarted}
          </ColorTypography>
          <ColorTypography color={colors.text.inProgress}>
            In progress: {event.assignmentsInProgress}
          </ColorTypography>
          <ColorTypography color={colors.text.done}>
            Done: {event.assignmentsDone}
          </ColorTypography>
        </Box>
      </CardActionArea>
    </Card>
  );
}
