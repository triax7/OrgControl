import { useDispatch, useSelector } from 'react-redux';
import Button from '@material-ui/core/Button';
import React from 'react';
import { getCurrentUser } from '../redux/slices/userSlice';

export default function UserDisplay() {
  const dispatch = useDispatch();

  const user = useSelector(state => state.user);

  return (
    <>
      <Button onClick={() => dispatch(getCurrentUser())}>Get User</Button>
      <div>{JSON.stringify(user)}</div>
    </>
  );
}
