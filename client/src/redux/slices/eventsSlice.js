import { createSlice } from '@reduxjs/toolkit';

const eventsSlice = createSlice({
  name: 'events',
  initialState: [],
  reducers: {
    getEvents() {
    },
    updateOrAddEvent(state, action) {
      const event = action.payload;
      const index = state.findIndex(e => e.id === event.id)
      if(index !== -1)
        state[index] = {...state[index], ...event};
      else
        state.push(event)
    },
    setEvents(state, action) {
      return action.payload;
    },
    createEvent(state, action) {
    }
  }
});

export const {
  getEvents,
  updateOrAddEvent,
  setEvents,
  createEvent
} = eventsSlice.actions;
export default eventsSlice.reducer;
