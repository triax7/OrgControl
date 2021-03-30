import React from 'react';
import { Grid } from '@material-ui/core';
import RoleManager from './RoleManager';
import { useParams } from 'react-router';

export default function EventPage() {

  const { id } = useParams();

  return (
    <Grid container justify={'center'}>
      <Grid item xs={5}>
        <RoleManager eventId={id}/>
      </Grid>
    </Grid>
  );
}


