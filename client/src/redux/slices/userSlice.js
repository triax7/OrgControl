import {createSlice} from '@reduxjs/toolkit';

const userSlice = createSlice({
  name: 'user',
  initialState: {},
  reducers: {
    getCurrentUser() {
    },
    registerUser(state, action) {
    },
    loginUser(state, action) {
    },
    setUser(state, action) {
      const userData = action.payload;
      return {...userData};
    }
  }
});

export const {getCurrentUser, setUser, registerUser, loginUser} = userSlice.actions;
export default userSlice.reducer;
