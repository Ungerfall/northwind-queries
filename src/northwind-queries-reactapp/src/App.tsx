import TasksTree from './components/TasksTree';
import { Layout, Header } from './App.style';
import './App.css';

const App = () => {
  return (
    <>
    <Layout>
      <Header>
        <p>
          Northwind BD Queries
        </p>
      </Header>
      <TasksTree />
    </Layout>
    </>
  );
}

export default App;
