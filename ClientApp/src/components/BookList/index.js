import React, { useState, useEffect } from "react";
import axios from "axios";
import Book from "../Book";
import SearchField from "../SearchField";

import "./style.scss";

const BookList = () => {
  const [books, setBooks] = useState([]);
  const [searchValue, setSearchValue] = useState("");
  const [filtered, setFiltered] = useState([]);

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const result = await axios("api/Books/Get?searchPhrase=text");
        setBooks(result.data);
      } catch (err) {
        console.log(err);
      }
    };
    fetchBooks();
  }, []);

  const handleSearchChange = e => {
    let currentList = [];
    let newList = [];
    if (e.target.value !== "") {
      currentList = books;
      newList = currentList.filter(item => {
        const lc = item.title.toLowerCase();
        const fc = item.authors[0].toLowerCase();
        const filter = e.target.value.toLowerCase();
        return lc.includes(filter) || fc.includes(filter);
      });
    } else {
      newList = books;
    }
    setFiltered(newList);
  };

  const onSearchValueChange = searchValue => {
    setSearchValue(searchValue);
  };

  const onSearchCancel = () => {
    setSearchValue("");
    setFiltered(books);
  };

  return (
    <main>
      <SearchField
        searchValue={searchValue}
        handleSearchChange={handleSearchChange}
        onSearchCancel={onSearchCancel}
        onSearchValueChange={onSearchValueChange}
      />
      <div className="book-list">
        {filtered.length > 0
          ? filtered.map(book => <Book key={book.title} book={book} />)
          : books.map(book => <Book key={book.title} book={book} />)}
      </div>
    </main>
  );
};

export default BookList;
