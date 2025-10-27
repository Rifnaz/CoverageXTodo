import Index from "./pages"
import { ToastContainer, toast } from 'react-toastify';

function App() {

  return (
    <>
      <Index/>
      <ToastContainer
        position="bottom-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={true}
        closeOnClick={true}
        rtl={false}
        pauseOnFocusLoss
        pauseOnHover
        theme="light"
        />
    </>
  )
}

export default App
