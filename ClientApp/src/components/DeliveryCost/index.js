import React, { useState, useEffect } from "react";
import axios from "axios";
import { withRouter, Link } from "react-router-dom";
import { Redirect } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";

import "./style.scss";

const useStyles = makeStyles(theme => ({
  button: {
    backgroundColor: "#eb7014",
    width: 100,
    color: "white",
    fontSize: 16,
    fontFamily:
      "-apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Oxygen, Ubuntu, Cantarell, Fira Sans, Droid Sans, Helvetica Neue, sans-serif"
  }
}));

const DeliveryCost = props => {
  const classes = useStyles();
  const [costs, setCosts] = useState([]);
  const [delivery, setDelivery] = useState("");
  const [info, setInfo] = useState("");
  const [redirect, setRedirect] = useState(false);
  const [state, setState] = useState({
    checkedA: false,
    checkedB: false,
    checkedC: false
  });

  const today = new Date();
  let date =
    today.getFullYear() + "-" + (today.getMonth() + 1) + "-" + today.getDate();

  useEffect(() => {
    const fetchDelivery = async () => {
      try {
        const result = await axios(`api/Books/DeliveryCosts?date=${date}`);
        setCosts(result.data);
      } catch (err) {
        console.log(err);
      }
    };
    fetchDelivery();
  }, []);

  const postDeliveryMethod = async () => {
    try {
      var model = {
        deliveryService: delivery
      };
      const result = await axios.post("api/Books/SubmitOrder", model);

      setInfo(result.data);
      setRedirect(true);
    } catch (err) {
      console.log(err);
    }
  };

  const handleChange = name => event => {
    setState({ ...state, [name]: event.target.checked });
    setDelivery(event.target.value);
  };

  const renderRedirect = info => {
    if (redirect) {
      return <Redirect to={{ pathname: "/thankyou", state: info }} />;
    }
  };

  return (
    <div>
      {renderRedirect(info)}
      <div className="delivery">
        {costs.map(cost => (
          <FormControlLabel
            key={cost.type}
            control={
              <Checkbox
                checked={state.checked}
                onChange={handleChange("checked")}
                value={cost.type}
                color="primary"
              />
            }
            label={`${cost.type} - $${cost.cost}`}
          />
        ))}
      </div>
      <div className="buttons">
        <Button
          style={{ marginRight: 30 }}
          className={classes.button}
          variant="contained"
          onClick={postDeliveryMethod}
        >
          Buy
        </Button>
        <Button
          className={classes.button}
          variant="contained"
          onClick={props.handleClose}
        >
          Cancel
        </Button>
      </div>
    </div>
  );
};

export default withRouter(DeliveryCost);
