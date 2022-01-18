import TasksTree from '../components/TasksTree';
import { MainLayout, HeaderLayout } from './App.style';

const App = () => {
  return (
    <>
    <HeaderLayout>
      <p>
        Northwind BD Queries
      </p>
    </HeaderLayout>
    <MainLayout>
      <aside>
        <TasksTree />
      </aside>
      <main>
        <p>
          QueryWindow
        </p>
      </main>
    </MainLayout>
    </>
  );
}

export default App;
