import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Fade from "@material-ui/core/Fade";
import DeliveryCost from "../DeliveryCost";

const useStyles = makeStyles(theme => ({
  modal: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center"
  },
  paper: {
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    borderRadius: 5,
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
    fontSize: 20,
    width: 500
  }
}));

const ModalDialog = props => {
  const classes = useStyles();

  return (
    <div>
      <Modal
        className={classes.modal}
        open={props.open}
        onClose={props.handleClose}
      >
        <Fade in={props.open}>
          <div className={classes.paper}>
            <div>
              <div style={{ display: "block", textAlign: "center" }}>
                <img src={`${props.book.image}`} alt={"book"} />
                <h3>{props.book.title}</h3>
                <p>
                  {props.book.authors} - {props.book.publishedDate}
                </p>
              </div>
              <p>Ship via</p>
              <DeliveryCost handleClose={props.handleClose} />
            </div>
          </div>
        </Fade>
      </Modal>
    </div>
  );
};

export default ModalDialog;
