import React, { useState } from "react";
import { Link } from "react-router-dom";
import Modal from "../Modal";
import "./style.scss";

const Book = ({ book }) => {
  const [open, setOpen] = useState(false);

  const handleOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div className="book">
      <Link to={""} style={{ textDecoration: "none" }} onClick={handleOpen}>
        <img src={`${book.image}`} alt={"book"} />
        <h3>{book.title}</h3>
        <p>
          {book.authors} - {book.publishedDate}
        </p>
      </Link>
      <Modal {...{ open, book }} handleClose={handleClose} />
    </div>
  );
};

export default Book;
