import { createSlice } from '@reduxjs/toolkit';

const assignmentsSlice = createSlice({
  name: 'assignments',
  initialState: [],
  reducers: {
    getAssignments() {
    },
    updateOrAddAssignment(state, action) {
      const assignment = action.payload;
      const index = state.findIndex(r => r.id === assignment.id);
      if (index !== -1)
        state[index] = {...state[index], ...assignment};
      else
        state.push(assignment);
    },
    setAssignments(state, action) {
      return action.payload;
    },
    createAssignment(state, action) {
    }
  }
});

export const {
  getAssignments,
  updateOrAddAssignment,
  setAssignments,
  createAssignment
} = assignmentsSlice.actions;
export default assignmentsSlice.reducer;
