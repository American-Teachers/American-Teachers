import React from 'react';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';
import blue from '@material-ui/core/colors/blue';
import grey from '@material-ui/core/colors/grey';

import './App.css';
import SignIn from './pages/SignIn';
import SignUp from './pages/SignUp';

const theme = createMuiTheme({
  palette: {
    primary: blue,
    secondary: grey,
  },
  status: {
    danger: 'orange',
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
    <BrowserRouter>
      <Routes>
        <Route path="/"  element={<SignIn />} />
        <Route path="/signup"  element={<SignUp />} />
        <Route path="/signin"  element={<SignIn />} />
    </Routes>
    </BrowserRouter>
  </ThemeProvider>
  );
}

export default App;
