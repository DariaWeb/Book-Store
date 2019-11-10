import React from 'react';
import { shallow } from 'enzyme';
import BookList from '../../components/BookList';
import axios from 'axios';
 
jest.mock('axios');
 
describe('BookList component', () => {
  describe('when rendered', () => {
    it('should fetch a list of books', () => {
      const getSpy = jest.spyOn(axios, 'get');
      const bookListInstance = shallow(
        <BookList/>
      );
      expect(getSpy).toBeCalled();
    });
  });
});