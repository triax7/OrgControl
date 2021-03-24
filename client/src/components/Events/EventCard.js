import Card from '@material-ui/core/Card';
import { CardActionArea } from '@material-ui/core';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import ColorTypography from '../util/ColorTypography';
import { colors } from '../../theme/colors';
import React from 'react';

export default function EventCard({event}) {
  function handleClick() {
    console.log(event);
  }

  return (
    <Card variant={'outlined'}>
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
