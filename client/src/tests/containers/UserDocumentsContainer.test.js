import UserDocumentContainer from '../../containers/Users/UserDocumentContainer';
import Enzyme, { render, shallow } from 'enzyme';
import React from 'react';
import Adapter from 'enzyme-adapter-react-15';
import configureStore from 'redux-mock-store';

Enzyme.configure({ adapter: new Adapter() });
const mockStore = configureStore();

const createMockStore = state => {
    const store = mockStore(state);
    return store;
}

const createDefaultComponent = state => {
  const store = createMockStore(state);
  const wrapper = shallow(<UserDocumentContainer store={store} />);

  return wrapper;
};

const createDefaultRenderedComponent = state =>{
    const store = createMockStore(state);
    const wrapper = render(<UserDocumentContainer store={store} />);

    return wrapper;
}

describe('<UserDocumentContainer>', () => {
  it('should render', () => {
    const initialState = {
      Documents: {
        documents: [],
      },
    };

    const component = createDefaultRenderedComponent(initialState);

    expect(component).toBeTruthy();
  });

  it('should get document list', () => {
    const initialState = {
      Documents: {
        documents: [
          {
            key: 'test.docx',
            modified: 123,
            size: 1.5 * 1024 * 1024,
          },
        ],
      },
    };

    const component = createDefaultComponent(initialState);

    expect(component.props().documents).toEqual(initialState.Documents.documents);
  });
});
