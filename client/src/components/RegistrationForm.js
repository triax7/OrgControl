import React from 'react';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { useDispatch } from 'react-redux';
import { Field, Form, Formik } from 'formik';
import { TextField } from 'formik-material-ui';
import { registerUser } from '../redux/slices/userSlice';
import { emailExists } from '../api/Accounts';

export default function RegistrationForm() {
  const dispatch = useDispatch();

  async function validate(values) {
    let errors = {};

    if (!/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(values.email)) {
      errors.email = 'Invalid e-mail';
    }

    if (await emailExists(values.email))
      errors.email = 'Email is taken';

    return errors;
  }

  function handleRegister(values) {
    dispatch(registerUser(values));
  }

  return (
    <Grid container justify={'center'}>
      <Grid item xs={3}>
        <Paper>
          <Formik
            initialValues={{email: '', name: '', password: ''}}
            validate={validate}
            onSubmit={handleRegister}
          >
            <Form>
              <Box p={3} dispay={'flex'} flexDirection={'column'}>
                <Field
                  component={TextField}
                  name="email"
                  label="Email"
                  fullWidth
                />
                <Box mt={2}>
                  <Field
                    component={TextField}
                    name="name"
                    label="Name"
                    fullWidth
                  />
                </Box>
                <Box mt={2}>
                  <Field
                    component={TextField}
                    name="password"
                    type="password"
                    label="Password"
                    fullWidth
                  />
                </Box>
                <Box mt={2} display={'flex'} justifyContent={'center'}>
                  <Button variant={'contained'} type={'submit'}>Register</Button>
                </Box>
              </Box>
            </Form>
          </Formik>
        </Paper>
      </Grid>
    </Grid>
  );
}
