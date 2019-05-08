import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Contact from './components/Contacts/Contact';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>      
            <Route exact path='/' component={Contact} />
        </Layout>
    );
  }
}
//<Route exact path='/' component={Home} />
