
import './App.css';
import Graphic from './components/Graphic/Graphic';
import Header from './components/Header/Header';
import InputForm from './components/InputForm/InputForm';



function App() {
  return (
    <div className="app-wrapper">
      <Header></Header>
      <InputForm></InputForm>
      <Graphic></Graphic>
    </div>
  );
}

export default App;
