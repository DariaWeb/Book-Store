import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import InputBase from "@material-ui/core/InputBase";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import ClearIcon from "@material-ui/icons/Clear";

const useStyles = makeStyles(theme => ({
  root: {
    margin: "20px 20px",
    padding: "2px 4px",
    display: "flex",
    alignItems: "center",
    width: 400
  },
  input: {
    marginLeft: theme.spacing(1),
    flex: 1
  },
  iconButton: {
    padding: 10
  },
  divider: {
    height: 28,
    margin: 4
  }
}));

const SearchField = props => {
  const classes = useStyles();

  return (
    <Paper className={classes.root}>
      <InputBase
        className={classes.input}
        placeholder="Search by book title or author"
        onChange={e => {props.onSearchValueChange(e.target.value); props.handleSearchChange(e)}}
        value={props.searchValue}
      />
      <Divider className={classes.divider} orientation="vertical" />
      <IconButton
        className={classes.iconButton}
        aria-label="directions"
        onClick={e => props.onSearchCancel(e)}
      >
        <ClearIcon />
      </IconButton>
    </Paper>
  );
};

export default SearchField;
