import React from 'react';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import './App.css';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';

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
