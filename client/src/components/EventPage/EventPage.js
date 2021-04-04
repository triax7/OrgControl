import React, { useEffect } from 'react';
import { Grid, Typography } from '@material-ui/core';
import { useParams } from 'react-router';
import Box from '@material-ui/core/Box';
import { useDispatch, useSelector } from 'react-redux';
import { getEvents } from '../../redux/slices/eventsSlice';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import Link from '@material-ui/core/Link';
import { push } from 'connected-react-router';
import RoleManager from './RoleManager';
import UserManager from './UserManager';

export default function EventPage({tab}) {
  const {id} = useParams();
  const event = useSelector(state => state.events.find(e => e.id === id));
  const dispatch = useDispatch();

  useEffect(() => {
    if (!event) dispatch(getEvents());
  }, [dispatch, event]);

  function handleTabClick(tab, clickEvent) {
    clickEvent.preventDefault();
    dispatch(push(`/events/${event.id}/${tab}`));
  }

  return (
    <>
      {!event ? <Typography>Loading...</Typography> :
        <Grid container justify={'center'}>
          <Grid item xs={5}>
            <Box display={'flex'} justifyContent={'center'} mb={3}>
              <Typography variant={'h4'}>{event.name}</Typography>
            </Box>
            <Box display={'flex'} justifyContent={'center'} mb={3}>
              <Breadcrumbs aria-label="breadcrumb">
                <Link color={tab === 'roles' ? 'textPrimary' : 'inherit'} href="#"
                      onClick={(e) => handleTabClick('roles', e)}>
                  Roles
                </Link>
                <Link color={tab === 'assignments' ? 'textPrimary' : 'inherit'} href="#"
                      onClick={(e) => handleTabClick('assignments', e)}>
                  Assignments
                </Link>
                <Link color={tab === 'users' ? 'textPrimary' : 'inherit'} href="#"
                      onClick={(e) => handleTabClick('users', e)}>
                  Users
                </Link>
              </Breadcrumbs>
            </Box>
            {tab === 'roles' && <RoleManager eventId={event.id}/>}
            {tab === 'users' && <UserManager eventId={event.id}/>}
          </Grid>
        </Grid>
      }
    </>
  );
}


