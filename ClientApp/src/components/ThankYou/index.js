import React from "react";
import "./style.scss";

const ThankYou = props => {
  
  return (
    <div className="thankyou">
      <h1 className="thankyou-title">Thank You for your order</h1>
      <p>{props.location.state}</p>
    </div>
  );
};

export default ThankYou;
