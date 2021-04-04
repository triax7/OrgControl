import Card from '@material-ui/core/Card';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import ColorTypography from '../../util/ColorTypography';
import { colors } from '../../../theme/colors';
import React from 'react';

export default function AssignmentCard({assignment, selected, onClick}) {

  const statuses = ['Not started', 'In progress', 'Done'];
  const statusColors = [colors.text.notStarted, colors.text.inProgress, colors.text.done];

  return (
    <Card variant={'outlined'} style={selected ? {backgroundColor: '#efefef'} : {}}
          onClick={onClick}>
        <Box p={2}>
          <Typography variant={'h6'}>
            {assignment.name}
          </Typography>
          <Typography>
            {assignment.description ?? 'No description provided'}
          </Typography>
        </Box>
        <Divider/>
        <Box p={2} style={{overflowX: 'auto'}} whiteSpace={'nowrap'} minHeight={3}>
          {assignment.allowedRoles.map(role =>
            <Box key={role.id} display={'inline-block'} mr={1} px={1} border={1}
                 borderRadius={20}>
              <Typography variant={'subtitle1'}>{role.name}</Typography>
            </Box>)
          }
        </Box>
        <Divider/>
        <Box p={2}>
          <ColorTypography color={statusColors[assignment.status]}>
            {statuses[assignment.status]}
            {assignment.status !== 0 && ` (${assignment.user.name})`}
          </ColorTypography>
        </Box>
    </Card>
  );
}
