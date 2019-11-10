'use strict';
module.exports = {
  get: () => {
    return Promise.resolve({
      data: [
        {
          id: 0,
          title: 'To kill a Mocking Bird',
          author: "Harper Lee"
        },
        {
          id: 1,
          title: 'The Adventures of Tom Sawyer',
          author: "Mark Twain"
        }
      ]
    });
  }
};