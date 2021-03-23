import { useDispatch, useSelector } from 'react-redux';
import React, { useEffect } from 'react';
import { getEvents, setEvent } from '../redux/slices/eventsSlice';
import Button from '@material-ui/core/Button';

export default function EventList () {
  const dispatch = useDispatch();

  const events = useSelector(state => state.events)

  useEffect(() => {
    dispatch(getEvents());
  }, [dispatch]);

  return (
    <>
      <Button onClick={() => dispatch(setEvent({id: events[0].id, name:'sus'}))}>test set event</Button>
      <div>{JSON.stringify(events)}</div>
    </>
  );
}
