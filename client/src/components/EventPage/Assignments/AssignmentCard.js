import Card from '@material-ui/core/Card';
import { CardActionArea } from '@material-ui/core';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import ColorTypography from '../../util/ColorTypography';
import { colors } from '../../../theme/colors';
import React from 'react';

export default function AssignmentCard({assignment}) {

  const statuses = ['Not started', 'In progress', 'Done'];
  const statusColors = [colors.text.notStarted, colors.text.inProgress, colors.text.done];

  return (
    <Card variant={'outlined'}>
      <CardActionArea>
        <Box p={2}>
          <Typography variant={'h6'}>
            {assignment.name}
          </Typography>
          <Typography>
            {assignment.description ?? 'No description provided'}
          </Typography>
        </Box>
        <Divider/>
        <Box p={2}>
          <Typography>
            Allowed roles: {assignment.allowedRoles.map(role => role.name).join(', ')}
          </Typography>
        </Box>
        <Divider/>
        <Box p={2}>
          <ColorTypography color={statusColors[assignment.status]}>
            {statuses[assignment.status]}
          </ColorTypography>
        </Box>
      </CardActionArea>
    </Card>
  );
}
