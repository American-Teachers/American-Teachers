import React from 'react';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import SignIn from './pages/SignIn';
import SignUp from './pages/SignUp';
import Landing from './pages/Landing';
import WhyUs from './pages/WhyUs';

const theme = createMuiTheme({
  palette: {
    primary: {
      main: '#FF6E4E',
      contrastText: '#FFFFFF'
    },
    text: {
      primary: '#5F5F5F'
    },
  },
  typography: {
    fontFamily:[
      'Open Sans',
      'sans-serif',
      '"Montserrat"'
    ]
  },
  status: {
    danger: 'orange',
  },
  // Used by `getContrastText()` to maximize the contrast between
  // the background and the text.
  contrastThreshold: 3,
  // Used by the functions below to shift a color's luminance by approximately
  // two indexes within its tonal palette.
  // E.g., shift from Red 500 to Red 300 or Red 700.
  tonalOffset: 0.2,
});

function App() {
  return (
    <ThemeProvider theme={theme}>
    <BrowserRouter>
      <Routes>
      <Route path="/"  element={<Landing />} />
        <Route path="/signup"  element={<SignUp />} />
        <Route path="/signin"  element={<SignIn />} />
        <Route path="/why-us" element={<WhyUs />} />
    </Routes>
    </BrowserRouter>
  </ThemeProvider>
  );
}

export default App;
