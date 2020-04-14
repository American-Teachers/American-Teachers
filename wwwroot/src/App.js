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
  typography: {
    fontStyle: 'normal',
    fontWeight: 'normal',
    fontSize: '18px',
    lineHeight:'25px',
    textDecorationColor: '#FF6E4E',
    button: {
      fontSize: '18px',
    },
    fontFamily:[
      'Open Sans',
      'sans-serif',
      '"Montserrat"'
    ],
    
  },
  overrides: {
    MuiContainer: {
    },
    MuiButton: {
      fullWidth: {
      },
      sizeLarge: {
      },
      label: {
        height: '42px',
      }
    },
    MuiFormControl: {
      fullWidth: {
        fontSize: '16px'
      },
    }
  },
  palette: {
    primary: { 
      main: '#FF6E4E',
      textPrimary: '#8B8B8B',
      contrastText: "white" // this will set button's texts to white
    },
    secondary: {main: '#8B8B8B'},
    background: {
      default: '#FFFFFF'
    },
    text: {
      primary: '#8B8B8B'
    }
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
