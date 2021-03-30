import { createSlice } from '@reduxjs/toolkit';

const rolesSlice = createSlice({
  name: 'roles',
  initialState: [],
  reducers: {
    getRoles() {
    },
    updateOrAddRole(state, action) {
      const role = action.payload;
      const index = state.findIndex(r => r.id === role.id);
      if (index !== -1)
        state[index] = {...state[index], ...role};
      else
        state.push(role);
    },
    setRoles(state, action) {
      return action.payload;
    },
    createRole(state, action) {
    },
    deleteRole(state, action) {
    },
    removeRoleFromState(state, action) {
      const index = state.findIndex(r => r.id === action.payload);
      state.splice(index, 1);
    }
  }
});

export const {
  getRoles,
  updateOrAddRole,
  setRoles,
  createRole,
  deleteRole,
  removeRoleFromState
} = rolesSlice.actions;
export default rolesSlice.reducer;
