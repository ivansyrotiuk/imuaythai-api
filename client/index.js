import React from "react"
import ReactDOM from "react-dom"
import {Router, Route, IndexRoute, hashHistory} from "react-router"
import { Provider } from "react-redux"

import store from "./store"
import Layout from "./components/pages/Layout"
import Dashboard from "./components/pages/Dashboard"
import Clients from "./components/pages/Clients"
import Modal from "./components/Modal"

const app = document.getElementById('app');
ReactDOM.render(
 <Provider store={store}>
    <Router history={hashHistory}>
    <Route path="/" component={Layout}>
        <IndexRoute component={Dashboard}></IndexRoute>
        <Route path="clients" name="clients" component={Clients}></Route>
        <Route path="dummyUsers(/:user)" name="users" component={Dashboard}></Route>
    </Route>
</Router></Provider>, app);



