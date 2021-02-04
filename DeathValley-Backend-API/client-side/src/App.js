
import { Route } from 'react-router-dom';
import './App.css';
import Header from './components/Header/Header';
import MainContent from './components/MainContent/MainContent';



function App() {
  return (
    <div className="app-wrapper">
      <Header/>
      <Route exact path='/' component={MainContent}></Route>
      <Route path='/about'></Route>
    </div>
  );
}

export default App;
