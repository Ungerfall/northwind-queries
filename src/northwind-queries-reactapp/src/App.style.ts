import styled from 'styled-components';

export const MainLayout = styled.div`
    display: flex;
    text-align: left;

    aside {
        width: 30%;
    }

    main {
        flex: 1;
        overflow: auto;
    }
`;
export const HeaderLayout = styled.header`
    background-color: #282c34;
    min-height: 10vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    font-size: calc(10px + 2vmin);
    color: white;
`;