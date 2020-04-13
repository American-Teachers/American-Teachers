import React, { useState } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import { Link } from 'react-router-dom';
import { Grid, Typography, Container, Button, Checkbox, FormControlLabel, InputAdornment, IconButton, InputLabel, FormControl, OutlinedInput } from '@material-ui/core';
import Visibility from '@material-ui/icons/Visibility';
import VisibilityOff from '@material-ui/icons/VisibilityOff';
import { makeStyles } from '@material-ui/core/styles';
import GoogleLogin from 'react-google-login';
import Icon from '@material-ui/core/Icon';
import Googlelogo from '../../public/google-icon.svg';
import emailValidation from '../helpers/email-validation';
import clsx from 'clsx';
import Privacy from '../../public/AmericanTeachersPrivacyStatement.pdf';
import TermsAndConditions from '../../public/AmericanTeachersTermsofUse.pdf'

const createGoogleIcon = (classes) => {
  return (
    <Icon classes={{root: classes.iconRoot}}>
       <img className={classes.imageIcon} src={Googlelogo} alt="Google logo"/>
    </Icon>
  )
}

const useStyles = makeStyles((theme) => ({
  wrap: {
    height: '100%',
  },
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(3),
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
  },
  textField: {
    width: '100%',
  },
}));

export default function SignUp() {
  const classes = useStyles();
  const [formValues, setFormValues] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password:'',
    termsAgreed: false,
    showPassword: false
  });
  // const [selectedDate, setSelectedDate] = useState(new Date('1990-08-18T21:11:54'));
  const [requiredFieldErrors, setRequiredFieldErrors] = useState({
    firstName: false,
    lastName: false,
    email: false,
    password: false
  });
  const responseGoogle = (response) => {
    console.log(response);
    const values = {
      firstName: response.profileObj.givenName,
      lastName: response.profileObj.familyName,
      email: response.profileObj.email,
    }
    setFormValues(values);
  }

  const handleChange = (name) => (event) =>  {
    event.persist();
    if(name === 'email'){
      setRequiredFieldErrors({ ...requiredFieldErrors, email: emailValidation(event.target.value)});
    } else {
      setRequiredFieldErrors({...requiredFieldErrors, [name]: event.target.value.length < 1 })
    }
    setFormValues({...formValues, [name]: event.target.value});
  };

  const handleCheckBox = () => (event) => {
    event.persist();
    setFormValues({...formValues, termsAgreed: event.target.checked});
  }

  const handleClickShowPassword = () => {
    setFormValues({ ...formValues, showPassword: !formValues.showPassword });
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const handleSignUp = () => {
    // TODO calling api to save and then upon successful sign up redirect to profile
  }

  const someValuesMissing = Object.values(requiredFieldErrors).some(field => field === true);
  const isButtonEnabled =  !someValuesMissing && formValues.termsAgreed;

  return (
    <Container component="main" maxWidth="md" className="wrap">
      <CssBaseline />
      <div className={classes.paper}>
        <Typography component="h1" variant="h5">
          Sign up
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
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                value={formValues.firstName}
                onChange={handleChange('firstName')}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="Last Name"
                name="lastName"
                autoComplete="lname"
                value={formValues.lastName}
                onChange={handleChange('lastName')}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
                value={formValues.email}
                onChange={handleChange('email')}
              />
            </Grid>
            <Grid item xs={12}>
              <FormControl className={clsx(classes.textField)} variant="outlined">
                <InputLabel htmlFor="outlined-adornment-password">Password</InputLabel>
                <OutlinedInput
                  id="outlined-adornment-password"
                  type={formValues.showPassword ? 'text' : 'password'}
                  value={formValues.password}
                  onChange={handleChange('password')}
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                      >
                        {formValues.showPassword ? <Visibility /> : <VisibilityOff />}
                      </IconButton>
                    </InputAdornment>
                  }
                  labelWidth={70}
                />
              </FormControl>
            </Grid>
            <Grid item xs={12}>
              <FormControlLabel
              control={
              <Checkbox
                required
                checked={formValues.termsAgreed}
                onChange={handleCheckBox()}
                color="primary" />
                }
                label="I agree to Privacy Statement and Terms of Use"
            />
              <Grid item xs={6}>
                <a href={Privacy} target = "_blank" rel="noopener noreferrer">Privacy Statement</a>
              </Grid>
              <Grid item xs={6}>
                <a href={TermsAndConditions} target = "_blank" rel="noopener noreferrer">Terms of Use</a>
              </Grid>
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            disabled={!isButtonEnabled}
            onClick={handleSignUp()}
          >
            Create Account
          </Button>
          <Grid container justify="flex-end" spacing={2}>
            <Grid item>
              <Typography>Already have an account? </Typography>
            </Grid>
            <Grid item>
                <Link color="secondary" to={'/signin'}>
                    Sign in
                </Link>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
  );
}