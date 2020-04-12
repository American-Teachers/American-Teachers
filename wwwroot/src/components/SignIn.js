import React from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import { Link } from 'react-router-dom';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import GoogleLogin from 'react-google-login';
import Icon from '@material-ui/core/Icon';
import Googlelogo from '../../public/google-icon.svg';

const responseGoogle = (response) => {
  console.log(response);
}

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  googleButton: {
    height: '50px',
    width: '100%',
    margin: '20px',
    fontSize: '1rem',
    lineHeight: '1.5',
  },
  imageIcon: {
    height: '100%',
    fontSize: '1.2rem'
  },
  iconRoot: {
    textAlign: 'start'
  }
}));

const createGoogleIcon = (classes) => {
  
  return (
    // <Icon classes={{root: classes.iconRoot}}>
    //             <img className={classes.imageIcon} src={Googlelogo} alt="Google logo"/>
    //           </Icon>
    <Icon classes={{root: classes.iconRoot}}>
       <img className={classes.imageIcon} src={Googlelogo} alt="Google logo"/>
    </Icon>
  )
}



export default function SignIn() {
  const classes = useStyles();

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>

        <GoogleLogin
          clientId="226277952430-u2vkjj2csmpbab2spttfpb8ti0jq3bcd.apps.googleusercontent.com"
          render={renderProps => (
            <Button variant="outlined" size="large" classes={{root: classes.googleButton}} onClick={renderProps.onClick} startIcon={createGoogleIcon(classes)}>
              Continue with Google
            </Button>
          )}
          buttonText="Continue with Google"
          onSuccess={responseGoogle}
          onFailure={responseGoogle}
          cookiePolicy={'single_host_origin'}
          isSignedIn={true}
        />
          <Typography component="p" >
          OR
        </Typography>
        <form className={classes.form} noValidate>
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            id="email"
            label="Email Address"
            name="email"
            autoComplete="email"
            autoFocus
          />
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
          />
          <FormControlLabel
            control={<Checkbox value="remember" color="primary" />}
            label="Remember me"
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
          >
            Sign In
          </Button>
          <Grid container>
            <Grid item xs>
              <Link to={"#"} variant="body2">
                Forgot password?
              </Link>
            </Grid>
            <Grid item>
                <Link color="secondary" to={'/signup'}>
                    Don't have an account? Sign Up
                </Link>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
  );
}