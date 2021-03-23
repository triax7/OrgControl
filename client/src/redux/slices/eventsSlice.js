import { createSlice } from '@reduxjs/toolkit';

const eventsSlice = createSlice({
  name: 'events',
  initialState: [],
  reducers: {
    getEvents() {
    },
    setEvent(state, action) {
      const event = action.payload;
      const index = state.findIndex(e => e.id === event.id)
      state[index] = {...state[index], ...event};
    },
    setEvents(state, action) {
      return action.payload;
    }
  }
});

export const {
  getEvents,
  setEvent,
  setEvents
} = eventsSlice.actions;
export default eventsSlice.reducer;
