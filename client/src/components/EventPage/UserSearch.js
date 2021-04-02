import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';
import React, { useEffect, useState } from 'react';
import { searchUsers } from '../../api/Users';

export default function UserSearch({onUserSelected}) {
  const [userList, setUserList] = useState([]);
  const [inputValue, setInputValue] = useState('');

  useEffect(() => {
    async function getUsers() {
      try {
        let {data} = await searchUsers(inputValue);
        setUserList(data);
      } catch (e) {
        console.log(e);
      }
    }
    getUsers();
  }, [inputValue]);

  return (
    <Autocomplete
      fullWidth
      options={userList}
      onChange={(event, newValue) => {
        onUserSelected(newValue);
      }}
      getOptionLabel={user => user.name}
      getOptionSelected={user => user.name}
      onInputChange={(event, newInputValue) => {
        setInputValue(newInputValue);
      }}
      renderInput={(params) => (
        <TextField
          {...params}
          label="Select User"
          variant="outlined"
        />
      )}
    />
  );
}
