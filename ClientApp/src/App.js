import React from "react";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";
import "./App.css";

import BookList from "./components/BookList";
import ThankYou from "./components/ThankYou";

const App = () => (
 
    <Router>
      <div className="App">
        <header className="App-header">
          <Link to="/">
            <h1 className="App-title">Augen Book Store</h1>
          </Link>
        </header>
        <Switch>
          <Route exact path="/" component={BookList} />
          <Route path="/thankyou" component={ThankYou} />
        </Switch>
      </div>
    </Router>

);

export default App;
