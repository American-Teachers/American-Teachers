import React, {useState} from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { Link } from 'react-router-dom';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import GoogleLogin from 'react-google-login';
import Icon from '@material-ui/core/Icon';
import Googlelogo from '../../public/google-icon.svg';
import emailValidation from '../helpers/email-validation';

import Layout from '../components/Layout';

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
    margin: '20px',
    color: '#8B8B8B',
    width: '100%'
  },
  imageIcon: {
    height: '100%',
    verticalAlign: 'super',
  },
  iconRoot: {
    textAlign: 'center',
    fontSize: '30px !important'
  }
}));

const createGoogleIcon = (classes) => {
  return (
    <Icon classes={{root: classes.iconRoot}}>
       <img className={classes.imageIcon} src={Googlelogo} alt="Google logo"/>
    </Icon>
  )
}

export default function SignIn() {
  const classes = useStyles();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [requiredFieldErrors, setRequiredFieldErrors] = useState({
    email: false,
    password: false
  });
  const [touched, setTouched] = useState({
      email: false,
      password: false,
  });
  const responseGoogle = (response) => {
    console.log(response);
  }

  const handleChange = (name) => (event) => {
    event.persist();
    if(name === 'email'){
      setRequiredFieldErrors({email: emailValidation(email)});
      setEmail(event.target.value);
    } else {
      setPassword(event.target.value);
    }
  };

  const handleBlur = (field) => () => {
    setTouched({ ...touched, [field]: true });
  }

  const handleSignIn = () => {
    // TODO calling api to login and then upon successful sign up redirect to profile
  }

  return (
    <Layout footerHidden>

    <Container component="main" maxWidth="sm">
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>

        <GoogleLogin
          clientId={process.env.CLIEND_ID}
          render={renderProps => (
            <Button variant="outlined" size='large' classes={{root: classes.googleButton}} onClick={renderProps.onClick} startIcon={createGoogleIcon(classes)}>
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
        <form className={classes.form} autoComplete="on">
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            id="email"
            label="Email"
            name="email"
            autoComplete="email"
            value={email}
            onChange={handleChange('email')}
            onBlur={handleBlur('email')}
            error={requiredFieldErrors.email}
            helperText={requiredFieldErrors.email ? 'Does not look like a valid email' : null}
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
            value={password}
            onChange={handleChange('password')}
            autoComplete="current-password"
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={handleSignIn()}
          >
            Sign In
          </Button>
          <Grid container spacing={2}>
            <Grid item xs>
              <Link to={"#"} variant="body2">
                Forgot password?
              </Link>
            </Grid>
            <Grid item>
              <Typography>Don't have an account? </Typography>
            </Grid>
            <Grid item>
              <Link color="secondary" to={'/signup'}>
                Sign Up
              </Link>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
    
    </Layout>
  );
}