import './App.css';

import {
  BrowserRouter,
  Routes,
  Route,
  Link,
} from 'react-router-dom';

import Navbar from './components/Navbar';
import NovelList from './pages/NovelList'

function App() {
  return (
    <div>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" element={<NovelList/>}/> 

        </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
