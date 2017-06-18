import React from "react";
import ReactDOM from "react-dom";
import {Router, Route, IndexRoute, hashHistory} from "react-router";

import Dashboard from "./pages/Dashboard";
import Clients from "./pages/Clients";
import Layout from "./pages/Layout";

const app = document.getElementById('app');
ReactDOM.render(
    <Router history={hashHistory}>
    <Route path="/" component={Layout}>
        <IndexRoute component={Dashboard}></IndexRoute>
        <Route path="clients" name="clients" component={Clients}></Route>
    </Route>
</Router>, app);