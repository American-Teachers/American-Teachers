import React from 'react';

import { FeatureCollection } from './Landing.js';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

import bannerImg from '../../public/whyus-banner.jpg';
import gettingImg from '../../public/whyus-gettingbetter.jpg';

const useStyles = makeStyles((theme) => ({
  root: {}
}))

export default function WhyUs() {
  return (
    <Layout>
      <div>
        <h3>Why Us</h3>
      </div>
      <FeatureCollection/>
    </Layout>
  )
}