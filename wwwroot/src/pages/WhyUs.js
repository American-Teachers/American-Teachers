import React from 'react';

import { Landing2 as WhyUs3 } from './Landing.js';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

import bannerImg from '../img/why-us/banner.jpg';
import gettingImg from '../img/why-us/getting-better.jpg';

const useStyles = makeStyles((theme) => ({
  root: {}
}))

export default function WhyUs() {
  return (
    <Layout>
      <div>whyus</div>
      <WhyUs3/>
    </Layout>
  )
}